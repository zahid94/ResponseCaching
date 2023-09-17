A basic visit to Response Caching along with its implementation in .NET

Response caching is a technique for storing the responses of an API or web application in a cache so that they can be served faster to subsequent requests.
The responses are stored in a cache with a key that uniquely identifies them, and the cache has a limited size and a policy for removing items when it becomes full.

𝐁𝐞𝐧𝐞𝐟𝐢𝐭𝐬 𝐨𝐟 𝐑𝐞𝐬𝐩𝐨𝐧𝐬𝐞 𝐂𝐚𝐜𝐡𝐢𝐧𝐠?

 1. Improved performance by reducing the load on the server.
 2. Reduced server load, as it can serve the cached response instead of generating a new one.
 3. Reduced bandwidth usage reduces the amount of data that needs to be transferred between the server and the client.
 4. Improved security as it can reduce the number of requests that reach the server, reducing the risk of certain types of attacks.

𝐎𝐧 𝐰𝐡𝐢𝐜𝐡 𝐫𝐞𝐪𝐮𝐞𝐬𝐭𝐬 𝐰𝐞 𝐜𝐚𝐧 𝐚𝐩𝐩𝐥𝐲 𝐑𝐞𝐬𝐩𝐨𝐧𝐬𝐞 𝐂𝐚𝐜𝐡𝐢𝐧𝐠

 1. Get
 2. Head

𝐅𝐞𝐰 𝐜𝐨𝐧𝐬𝐭𝐫𝐚𝐢𝐧𝐭𝐬 𝐟𝐨𝐫 𝐑𝐞𝐬𝐩𝐨𝐧𝐬𝐞 𝐂𝐚𝐜𝐡𝐢𝐧𝐠
 1. The request must result in a server response with a 200 (OK) status code.
 2. Response Caching Middleware must be placed before middleware that requires caching. For more information, see ASP.NET Core Middleware.
 3. The Authorization header must not be present.
 4. Cache-Control header parameters must be valid, and the response must be marked public and not marked private.
 5. The Content-Length header value (if set) must match the size of the response body.
𝐒𝐨𝐦𝐞 𝐫𝐞𝐚𝐥-𝐰𝐨𝐫𝐥𝐝 𝐞𝐱𝐚𝐦𝐩𝐥𝐞𝐬 𝐨𝐟 𝐑𝐞𝐬𝐩𝐨𝐧𝐬𝐞 𝐂𝐚𝐜𝐡𝐢𝐧𝐠
 1. News website
 2. E-commerce websites In your application you can apply response caching to those requests whose response is changed after a time and you are sure about it.
 
𝐇𝐨𝐰 𝐜𝐚𝐧 𝐈 𝐯𝐞𝐫𝐢𝐟𝐲 𝐢𝐭? 
Create an application apply caching and then request it from Postman and set the time to 60 minutes, you will notice that only the first request will reach the controller, 
after that even if you try request will not reach the controller.
 
