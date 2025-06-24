# Technical Plan – Matchify Swipe-to-Match Platform

## 1. Overview

Matchify is a mobile app and backend platform for swiping and matching users with different types of content (recipes, travel destinations, workouts, etc.). The platform is designed to be flexible and scalable, supporting real-time matching and integration with external content databases.

---

## 2. System Architecture

```plaintext
[React Native Mobile App (Expo)]
         ↕ REST API + SignalR
    [ASP.NET Core Web API Server]
         ↕ MongoDB Atlas (NoSQL DB)
         ↕ External Content APIs (optional)
Frontend: React Native app built with Expo for cross-platform (iOS and Android).

Backend: ASP.NET Core Web API handling authentication, API endpoints, business logic, and real-time communication with SignalR.

Database: MongoDB Atlas storing users, content, swipes, and matches.

External API: Optional integration layer for fetching and normalizing third-party data.

3. Key Components
3.1 Frontend (React Native)
Swipe UI: Displays content cards for users to swipe right/left.

Authentication: JWT-based login and registration.

Real-time updates: SignalR client to display matches instantly.

Content Views: Dynamic views based on content type.

Content Upload: Users can add new content items.

3.2 Backend (ASP.NET Core API)
Authentication: JWT + OAuth support.

Content Management: CRUD operations for content.

Swipe Management: Logs user swipes.

Match Engine: Logic that identifies matches when two users swipe right on the same content.

SignalR Hub: Pushes real-time notifications to clients upon matches.

External API Integration: Adapter layer for third-party data sources.

3.3 Database (MongoDB)
Users: User profiles and authentication data.

ContentItems: Content with metadata (type, title, images, descriptions, etc.).

Swipes: Logs of user swipe decisions.

Matches: Records linking two users to a content item when matched.

4. Data Models (Simplified)
json
Kopiera
Redigera
// User
{
  "_id": "ObjectId",
  "username": "string",
  "email": "string",
  "passwordHash": "string",
  "profileImageUrl": "string",
  "preferences": { /* user preferences, e.g. content types */ },
  "createdAt": "Date"
}

// ContentItem
{
  "_id": "ObjectId",
  "type": "string", // e.g. recipe, travel, workout
  "title": "string",
  "description": "string",
  "images": ["string"], // URLs
  "metadata": { /* flexible key-value for extra info */ },
  "createdBy": "UserId",
  "createdAt": "Date"
}

// Swipe
{
  "_id": "ObjectId",
  "userId": "UserId",
  "contentId": "ContentItemId",
  "direction": "left" | "right",
  "timestamp": "Date"
}

// Match
{
  "_id": "ObjectId",
  "userIds": ["UserId", "UserId"],
  "contentId": "ContentItemId",
  "matchedAt": "Date"
}
5. API Endpoints (Example)
Method	Endpoint	Description
POST	/api/auth/register	Register new user
POST	/api/auth/login	Login user, returns JWT
GET	/api/content	Get list of swipeable content items
POST	/api/content/swipe	Submit a swipe (left/right)
GET	/api/matches	Get list of matches for the user
POST	/api/content	Upload new content item

6. Real-time Communication
SignalR Hub:
Server pushes notifications about new matches to both users in real time.

Client:
React Native app subscribes to the hub and displays notifications when a match occurs.

7. Security
JWT is used for authentication and authorization.

HTTPS is required for all API calls.

Passwords are stored as salted hashes.

CORS policy restricts backend access to authorized frontend apps.

8. Development Plan
Milestone 1: Set up backend with user management and content API.

Milestone 2: Build basic swipe UI in React Native.

Milestone 3: Implement swipe logic and match engine.

Milestone 4: Add real-time features with SignalR.

Milestone 5: Implement content upload and external API integrations.

Milestone 6: Testing, bug fixing, and release.

9. Tools & Libraries
Backend: ASP.NET Core, SignalR, MongoDB.Driver

Frontend: React Native, Expo, Axios, @microsoft/signalr

Database: MongoDB Atlas

Authentication: JWT, OAuth (optional)

Development: Visual Studio, VS Code, Postman

10. Notes
This is a flexible platform designed for multiple content types.

API and data models should be designed with extensibility in mind.

Focus on user experience and real-time interaction.
