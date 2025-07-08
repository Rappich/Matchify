# Matchify – UNDER DEVELOPMENT

**Matchify** is a mobile-first, swipe-to-match platform where users browse through various types of content — such as recipes, travel destinations, movies, or workouts. When two users both swipe right on the same item, they are matched and can explore the content together using collaborative features like shared lists, plans, or chats.

> _Note: This repository focuses on showcasing technical implementation and structure. Some business-critical features and architecture details are intentionally excluded to protect potential future commercial use._

---

## Vision

To build a reusable, modular matchmaking engine that works across multiple verticals — including food, fitness, entertainment, travel, and education. The platform is designed to integrate with external content providers and enrich their products with swipe-based, social discovery features.

---

## Purpose

This project has two primary goals:

1. **Learning and professional development** – to explore new technologies and build real-world experience with scalable architecture.  
2. **Proof of concept** – to validate a flexible "swipe-to-match" engine that could, in the future, serve as a complementary module for external platforms.

> _Please note: This is an early-stage technical prototype, not a finalized product._

---

## Use Case Examples

- **Entertainment** – Match Netflix-style content with a friend or partner  
- **Food inspiration** – Swipe and match ICA recipes for dinner ideas  
- **Anonymous job matching** – Match job seekers and employers based on preference, experience, and skills  
- **Travel planning** – Swipe through destinations and match with friends or community members  

---

## Tech Stack

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

## Architecture

React Native (Expo)
↓
REST API + SignalR
↓
ASP.NET Core Web API
↓
MongoDB Atlas (NoSQL)


---

## Key Features

- User registration and login (JWT)  
- Swipe left/right on dynamic content cards  
- Real-time match notifications via SignalR  
- Collaborative “match” features (shared lists, actions, chats)  
- Upload and browse custom content with metadata and images  
- Extendable content types (recipes, recruitment, movies, travel, etc.)  
- Ready for external API integration  

---

## Scalability & Reusability

Matchify is built to support **multiple content types and data sources**. Switching between verticals (e.g., Travel → Recipes → Jobs) requires only minor changes to content schemas and UI presentation.

This makes Matchify a flexible, reusable engine for "swipe-to-match" discovery across different domains.

---

## File Structure

MATCHIFY - TBA
│
├── backend 
├── Docs
├── frontend





---

## Setup Instructions – TBA

### Frontend (React Native with Expo)

```bash
npm install -g expo-cli
git clone <your-repo>
cd frontend
npm install
expo start
Backend (.NET Core API)

cd backend/BackendAPI
dotnet restore
dotnet run
⚠️ Don’t forget to configure your .env or appsettings.json for DB connection strings and JWT secrets.

API Overview
Method	Endpoint	Description
POST	/api/auth/register	Register a new user
POST	/api/auth/login	Login and receive JWT
GET	/api/content	Fetch swipeable content
POST	/api/content/swipe	Submit swipe decision
GET	/api/matches	Fetch mutual matches
POST	/api/content	Upload new content item

Developer Tools
Expo Go (mobile testing)
MongoDB Atlas (cloud DB)
Postman (API testing)
VS Code / Visual Studio (backend)

Documentation
See the /Docs folder for:
TECHPLAN.md – system architecture and API design
ROADMAP.md – feature roadmap and development milestones
LEARNINGPLAN.md – technical learning plan and resources

Developer Intent
This project is built as part of my journey to become a full-time software developer, with a focus on backend architecture, API design, and scalable systems. I'm continuously learning, iterating, and applying industry practices to strengthen my understanding.

