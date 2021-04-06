using System;
using Dapper;
using System.Threading.Tasks;
using MySqlConnector;

namespace IdentityServer4
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpContextLogHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public static async Task<int> LogAsync(AuditLog auditLog)
        {
            string queryCommand = @"
                         INSERT INTO abpauditlogs
                                    (
                                    Id,
                                    ApplicationName,
                                    UserName,
                                    ExecutionTime,
                                    ExecutionDuration,
                                    ClientIpAddress,
                                    CorrelationId,
                                    BrowserInfo,
                                    HttpMethod,
                                    Url,
                                    HttpStatusCode
                                    )
                                    VALUES
                                    (
                                    @Id,
                                    @ApplicationName,
                                    @UserName,
                                    @ExecutionTime,
                                    @ExecutionDuration,
                                    @ClientIpAddress,
                                    @CorrelationId,
                                    @BrowserInfo,
                                    @HttpMethod,
                                    @Url,
                                    @HttpStatusCode
                                    );
                        ";
            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = "Server=106.13.130.51;Port=3306; database=CmsKit; UID=root; password=zxcvbnm; SSLMode=none;allowPublicKeyRetrieval=true";
            conn.Open();
            MySqlTransaction tran = conn.BeginTransaction();
            int balance = 0;
            try
            {
                balance = await conn.ExecuteAsync(queryCommand, new
                {
                    Id = auditLog.Id,
                    ApplicationName = auditLog.ApplicationName,
                    UserName = auditLog.UserName,
                    ExecutionTime = auditLog.ExecutionTime,
                    ExecutionDuration = auditLog.ExecutionDuration,
                    ClientIpAddress = auditLog.ClientIpAddress,
                    CorrelationId = auditLog.CorrelationId,
                    BrowserInfo = auditLog.BrowserInfo,
                    HttpMethod = auditLog.HttpMethod,
                    Url = auditLog.Url,
                    HttpStatusCode = auditLog.HttpStatusCode
                }, transaction: tran);
                await tran.CommitAsync();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                tran.Dispose();
                await conn.CloseAsync();
            }
            return balance;
        }
    }
}
