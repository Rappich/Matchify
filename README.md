# Matchify – UNDER DEVELOPMENT

**Matchify** is a mobile-first, swipe-to-match platform where users browse through various types of content, such as recipes, travel destinations, movies, or workouts. When two users both swipe right on the same item, they are matched and can explore the content together using collaborative features like shared lists, plans, or chats.

> _Note: This repository focuses on showcasing technical implementation and structure. Some business-critical features and architecture details are intentionally excluded to protect potential future commercial use._


---

## Vision

To build a reusable, modular matchmaking engine that works across multiple verticals, including food, fitness, entertainment, travel, and education. The platform is designed to integrate with external content providers and enrich their products with swipe-based, social discovery features.

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
> _The tech stack is subject to change based on internship priorities, evolving goals, and exploration of new tools._

### Frontend – Mobile App (React Native)
- React Native with Expo (iOS & Android)  
- Axios (API communication)  
- React Navigation (screen transitions)  
- SignalR client (real-time match updates)  
- AsyncStorage (JWT token storage)

### Backend – Web API
- **Python** with **FastAPI** (async web framework)  
- **MongoDB** Atlas (NoSQL database for users, content, matches)  
- **JWT Authentication** via `pyjwt` or `fastapi-jwt-auth`  
- **WebSocket** (FastAPI + `starlette` WebSocket support) for real-time notifications  
- Image upload support and external API integration

### DevOps & Infrastructure
- **Version Control:** Git & GitLab  
- **CI/CD Pipelines:** GitLab CI/CD automates backend/frontend build & tests  
- **Repository Hosting:** Primary repo on GitLab, with automatic mirroring to GitHub for visibility and portfolio  
- **GitLab pipelines run on every commit to:
  - Build and test FastAPI backend
  - Lint and verify React Native frontend
- **Containerization:** Dockerized backend  
- **Infrastructure Automation:** Ansible (planned)  
- **Hosting:** Linux-based (Ubuntu) servers  
- **Scripting:** Bash & Python scripts  
- **Security:** JWT, environment secrets, OWASP best practices  

---

## Architecture

React Native (Expo)
        ↓
REST API + WebSocket (FastAPI)
        ↓
FastAPI Backend Server
        ↓
MongoDB Atlas (NoSQL)

---

## Key Features

- **User registration and login** (JWT)  
- **Swipe left/right** on dynamic content cards  
- **Real-time match notifications** via WebSocket  
- **Collaborative “match” features** (shared lists, actions, chats)  
- **Upload and browse custom content** with metadata and images  
- **Extendable to multiple content types** (recipes, movies, jobs, travel)  
- **Designed for external API integration**

---

## Scalability & Reusability

Matchify supports **multiple verticals and content types**. You can swap between Travel, Food, Jobs, and more by changing only the content schemas and UI logic — the core engine remains unchanged.

---

## File Structure

MATCHIFY
│
├── backend       # FastAPI backend
├── Docs          # Architecture & planning documents
├── frontend      # React Native frontend

---

## API Overview

| Method | Endpoint             | Description                     |
|--------|----------------------|---------------------------------|
| POST   | `/api/auth/register` | Register a new user             |
| POST   | `/api/auth/login`    | Login and receive JWT           |
| GET    | `/api/content`       | Fetch swipeable content         |
| POST   | `/api/content/swipe` | Submit swipe decision           |
| GET    | `/api/matches`       | Fetch mutual matches            |
| POST   | `/api/content`       | Upload new content item         |

---

## Developer Tools

- **Expo Go** – Mobile testing  
- **MongoDB Atlas** – Cloud database  
- **Postman / Insomnia** – API testing  
- **VS Code / PyCharm** – Backend development environments

---

## Documentation

See the `/Docs` folder for:

- `TECHPLAN.md` – System architecture and API design  
- `ROADMAP.md` – Feature roadmap and milestones  
- `LEARNINGPLAN.md` – Technical growth and research  
- `SETUP.md` – Environment setup and instructions

---

## Developer Intent

This project is part of my professional journey toward **backend engineering**. It combines hands-on learning with **production-level practices** and aims to showcase skills in:

- System architecture  
- Real-time application design  
- API-first development  
- DevOps and CI/CD integration

---
