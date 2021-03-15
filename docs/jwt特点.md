https://www.jianshu.com/p/af8360b83a9f

在Web应用中，不要把JWT当做session使用，绝大多数情况下，传统的cookie-session机制工作得更好
JWT适合一次性的命令认证，颁发一个有效期极短的JWT，即使暴露了危险也很小，由于每次操作都会生成新的JWT，因此也没必要保存JWT，真正实现无状态。
