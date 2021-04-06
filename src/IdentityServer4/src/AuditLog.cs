using System;

namespace IdentityServer4
{
    /// <summary>
    /// 
    /// </summary>
    public class AuditLog
    {
        public string ApplicationName { get; set; }

        public Guid Id { get; protected set; } = System.Guid.NewGuid();

        public string UserName { get;  set; }

        public DateTime ExecutionTime { get;  set; } = DateTime.Now;
        public int ExecutionDuration { get; set; } = 1;

        public string ClientIpAddress { get;  set; }

        public string ClientId { get; set; }

        public string CorrelationId { get; set; }

        public string BrowserInfo { get;  set; }

        public string HttpMethod { get;  set; }

        public string Url { get;  set; }

        public string Exceptions { get;  set; }

        public virtual string Comments { get;  set; }

        public int? HttpStatusCode { get; set; }

        public AuditLog()
        {

        }
    }

}
