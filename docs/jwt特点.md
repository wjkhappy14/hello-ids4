https://www.jianshu.com/p/af8360b83a9f

在Web应用中，不要把JWT当做session使用，绝大多数情况下，传统的cookie-session机制工作得更好
JWT适合一次性的命令认证，颁发一个有效期极短的JWT，即使暴露了危险也很小，由于每次操作都会生成新的JWT，因此也没必要保存JWT，真正实现无状态。
JWT，则需要使用RS256算法生成非对称签名，这意味着必须使用私钥来签名JWT token，并且必须使用对应的公钥来验证token签名,即验证token是否有效。使用RS256可以保证IS4服务端是JWT的唯一签名者，因为IS4服务端是唯一拥有私钥的一方，前提是私钥不会被泄露。所以我们需要一个证书为我们提供私钥和公钥。在开发环境可以利用IS4的AddDeveloperSigningCredential 方法生成RSA文件，RSA文件为我们提供私钥和公钥，但是RSA文件不够安全，打开文件可以直接看到公钥和私钥，在生产环境我们一般会生成证书来提供私钥和公钥
在CMD中执行以下命令
openssl req -newkey rsa:2048 -nodes -keyout cas.clientservice.key -x509 -days 365 -out cas.clientservice.cer
在C:\WINDOWS\system32目录下面找到cas.clientservice.cer和cas.clientservice.key两个文件
将生成的证书和Key封装成一个文件，以便IdentityServer可以使用它们去正确地签名tokens，文件会生成在CMD执行目录下面“C:\WINDOWS\system32”
openssl pkcs12 -export -in cas.clientservice.cer -inkey cas.clientservice.key -out IS4.pfx
IS4.pfx是证书名称，可以自己修改，中途会提示输入Export Password，这个password在IS4中会用到，需要记下来

JWT 由三部分组成
header.payload.signature
其中, 使用私钥生成签名（signature）
资源服务器会向 ids4 公钥接口（/.well-known/openid-configuration/jwks）获取公钥，资源服务器再利用公钥解密签名，若解密成功，并且与header.payload 一致，则成功，未经篡改
header kid 即为 Key ID，用于防止重放攻击

 builder.AddDeveloperSigningCredential()
 会生成 tempkey.jwk，其中有公钥、私钥
 tempkey.jwk 在 kid(Key ID)，用于防止重放攻击

JwtBearerOptions配置，通过配置Authority属性，以http的方式获取授权中心的证书

JWT之非对称，对称加密：
JWT 不一定要使用 非对称加密，当使用非对称签名，才有公钥、私钥，只有ids4持有私钥，由资源服务器向ids4请求获取公钥
也可以使用对称加密，例如 HS256，这时只有一个秘钥，加密用它，解密也用它，仅 ids4 和资源服务器 拥有
此时,
signature = HMACSHA256(
  base64UrlEncode(header) + "." +
  base64UrlEncode(payload),
  "your-256-bit-secret"
)