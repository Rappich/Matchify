# Matchify – Swipe-to-Match Content Platform

**Matchify** is a mobile-first, swipe-to-match app platform where users swipe through various types of content — recipes, travel destinations, movies, workouts, or any custom content type. When two users both swipe right on the same item, they are matched and can explore the content together, unlocking features like shared lists, plans, or chats.

---

## 🌐 Vision

Build a reusable, modular matchmaking engine that works across multiple verticals — food, fitness, entertainment, travel, education, and more. The platform is designed to integrate with external content providers, allowing it to plug into existing products and enrich them with a swipe-based, social discovery experience.

---

## 🚀 Proof of Concept – A Universal Swipe-to-Match Layer

This project serves as a **proof of concept** for a flexible and extensible "swipe-to-match" engine. It acts as a complementary module to existing services (like Netflix, ICA, SF Anytime, learning platforms) — enabling social and interactive exploration of content.

Users can log in, swipe through content (e.g., recipes or movies), and match with others who like the same things. It’s designed to work on top of various data sources and content types.

### 🎯 MVP Focus: Travel Match

The pilot version focuses on travel inspiration. Users swipe through travel destinations, and when a mutual right-swipe occurs, they unlock a shared favorites view, chat, and suggested itineraries.

---

## 🧠 Use Cases

- 🍿 **“What should we watch?”** – Match Netflix-style content with a friend or partner
- 🥘 **“What should we eat?”** – Swipe and match ICA recipes for dinner ideas
- 💼 **“Who’s the right fit?”** – Match job seekers and employers based on preferences or skills
- 📚 **“What should we learn?”** – Swipe through courses and match with others in your learning track

---

## ⚙️ Tech Stack

### Frontend – Mobile App (React Native)

- React Native with Expo (iOS & Android)
- Axios (API communication)
- React Navigation (screen transitions)
- SignalR client (real-time match updates)
- AsyncStorage (JWT token storage)

### Backend – Web API

- ASP.NET Core Web API (C#)
- SignalR (real-time notifications)
- JWT Authentication
- MongoDB Atlas (NoSQL database for users, content, matches)
- Support for image uploads and third-party API integration

### DevOps & Infrastructure

- **Version Control:** Git & GitLab with branching strategy  
- **CI/CD Pipelines:** GitLab CI/CD automating build, test, and deployment  
- **Containerization:** Docker ensures consistent backend environments  
- **Infrastructure Automation:** Ansible for provisioning, configuration, and deployment automation  
- **Hosting:** Linux-based servers (Ubuntu LTS) for production environments  
- **Scripting:** Bash & Python scripts for setup, maintenance, and automation  
- **Security:** JWT authentication, environment variables for secrets, and OWASP best practices 
---

## 🧱 Architecture

React Native (Expo)
⬇️ REST API + SignalR
ASP.NET Core Web API
⬇️
MongoDB Atlas (NoSQL)

---

## ✨ Key Features

- 🔐 User registration and login (JWT)
- 👆 Swipe left/right on dynamic content cards
- 🔔 Real-time match notifications via SignalR
- 🤝 Collaborative “match” features (shared lists, actions, chats)
- 🖼️ Upload and browse custom content with metadata and images
- 🔌 Extendable content types (recipes, workouts, movies, travel, etc.)
- 🌍 Ready for external API integration

---

## 🌱 Scalability & Reusability

Matchify is designed to work with **multiple data sources and content types**. To adapt the app to a new context, developers only need to:

1. Switch the `contentType` (e.g. from `"Travel"` to `"Recipe"` or `"Movie"`)
2. Adjust the backend content schema and metadata
3. Customize the card UI in the frontend
4. (Optional) Connect to an external API (e.g., Netflix catalog or ICA recipes)

This makes the app a powerful **plug-and-play interaction layer** on top of existing content platforms.

---

## 📦 File Structure

/matchify
/backend
/Controllers
/Models
/Services
/Data
/Hubs
Program.cs
Startup.cs
appsettings.json

/frontend
/src
/components
/screens
/navigation
/services
/assets
App.js
app.json

/docs
README.md
technical-plan.md
roadmap.md
learning-plan.md


---

## 🛠️ Setup Instructions

### Frontend (React Native with Expo)
```bash
npm install -g expo-cli
git clone <your-repo>
cd client
npm install
expo start
Backend (.NET Core API)
bash
Copy
Edit
cd server
dotnet restore
dotnet run
⚠️ Don’t forget to configure your .env or appsettings.json for DB connection strings and JWT secrets.

🌍 API Overview
Method	Endpoint	Description
POST	/api/auth/register	Register a new user
POST	/api/auth/login	Login and receive JWT
GET	/api/content	Fetch swipeable content
POST	/api/content/swipe	Submit swipe decision
GET	/api/matches	Fetch mutual matches
POST	/api/content	Upload new content item

🧪 Developer Tools
Expo Go (mobile testing)

MongoDB Atlas (cloud DB)

Postman (API testing)

VS Code / Visual Studio (backend)

📚 Documentation
See /docs folder for:

technical-plan.md – system architecture and API design

roadmap.md – feature roadmap and development milestones

learning-plan.md – technical learning plan and resources
