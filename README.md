# 📱 Matchify – Swipe-to-Match Content Platform

**Matchify** is a mobile-first swipe-to-match app platform where users swipe through various types of content — recipes, travel destinations, workouts, or any custom content type. When two users both swipe right on the same item, they are matched and can explore the content together, unlocking personalized features like shared lists, plans, or chats.

---

## 🌐 Vision

Create a flexible, extensible matchmaking engine that can power apps across multiple verticals — food, fitness, travel, education, and beyond. This platform can integrate with external content providers, enabling partnerships and access to vast databases.

---

## 📲 Tech Stack

### Frontend – Mobile App (React Native)
- React Native with **Expo** (iOS & Android support)
- Axios (for API communication)
- React Navigation (for smooth screen transitions)
- SignalR client (for real-time match updates)
- AsyncStorage (for JWT token storage)

### Backend – Web API
- ASP.NET Core Web API (C#)
- SignalR (real-time notifications)
- JWT Authentication (stateless)
- MongoDB (NoSQL database for users, content, matches)
- Support for image uploads and external API integration

---

## 🧱 Architecture

React Native App (Expo)
↕️ REST + SignalR
ASP.NET Core Web API
↕️
MongoDB Atlas (NoSQL database)

yaml
Kopiera
Redigera

---

## ✨ Key Features

- 🔐 User registration and login (JWT)
- 👆 Swipe left/right on dynamic content cards
- 🔔 Real-time match notifications via SignalR
- 📋 Auto-generated “action lists” or collaborative features triggered on match
- 🖼️ Upload and browse custom content with images and metadata
- 🔌 Extensible content types: recipes, workouts, travel, and more
- 🤝 Potential for integration with third-party content APIs

---

## ⚙️ Setup Instructions

### 1. Frontend (React Native with Expo)

```bash
npm install -g expo-cli
git clone <your-repo>
cd client
npm install
expo start
2. Backend (.NET Core API)
bash
Kopiera
Redigera
cd server
dotnet restore
dotnet run
⚠️ Remember to configure environment variables for database connection strings and JWT secrets.

🌍 API Overview
Method	Endpoint	Description
POST	/api/auth/register	Register user
POST	/api/auth/login	Login and get JWT
GET	/api/content	Fetch swipeable content items
POST	/api/content/swipe	Send swipe decision
GET	/api/matches	Fetch matched content
POST	/api/content	Upload new content item

🧪 Tools You’ll Use
Expo Go (for mobile preview)

MongoDB Atlas (cloud-hosted database)

Postman (API testing)

Visual Studio Code + Visual Studio (.NET backend)

📚 Documentation
See the docs/ folder for:

technical-plan.md – system architecture and API design

roadmap.md – feature roadmap and milestones

learning-plan.md – learning resources and schedule
