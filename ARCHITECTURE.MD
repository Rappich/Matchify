+--------------------+              +-----------------------+              +-------------------+
|                    |   HTTP/API   |                       |   Database   |                   |
|   React Native     | <----------> |   ASP.NET Core Web API | <----------> |     MongoDB       |
|   Mobile App       |              |   (Backend Server)     |              |                   |
+--------------------+              +-----------------------+              +-------------------+
         |                                 |     ^
         |                                 |     | SignalR (Real-time)
         | SignalR Connection (WebSocket) |     |
         v                                 v     |
+--------------------+              +-----------------------+
|                    |              |                       |
|  User Interaction   |              |   SignalR Hub for     |
|  (Swipe, Login)     |              |   Real-Time Matches   |
+--------------------+              +-----------------------+
