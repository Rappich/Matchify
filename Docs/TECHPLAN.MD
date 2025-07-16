# Technical Plan

## Overview

This project aims to build a cross-platform mobile app with React Native (Expo) for the frontend and a Python FastAPI backend. The backend will use MongoDB as the database and support real-time features through WebSockets. Deployment and automation will rely on Docker and Ansible.

---

## Frontend

- **Framework:** React Native (Expo)  
- **Main features:**  
  - User authentication (JWT)  
  - Swipeable content cards  
  - Real-time match notifications via WebSocket  
  - Profile management and content upload screens  
- **Testing:** Jest and React Native Testing Library  
- **Build:** Expo build tools, CI integration  

---

## Backend

- **Framework:** FastAPI (Python 3.10+)  
- **Authentication:** JWT tokens with OAuth2 password flow  
- **Database:** MongoDB (Atlas for cloud)  
- **Real-time:** WebSocket endpoints with Starlette/FastAPI  
- **Content Model:** CRUD APIs for content and user data  
- **Deployment:** Docker containers orchestrated with Docker Compose and Ansible  
- **Testing:** Pytest for unit and integration tests  

---

## Infrastructure & Deployment

- **Containerization:** Docker for backend and local MongoDB development  
- **Orchestration:** Docker Compose for local dev, Ansible for server provisioning and deployment  
- **CI/CD:** GitHub Actions or GitLab CI pipelines for build, test, and deploy automation  
- **Monitoring:** Basic logging with Python logging module, extendable with cloud monitoring tools  

---

## Optional & Future Enhancements

- External API content integration  
- Performance optimizations (DB indexing, caching)  
- Push notifications (Firebase Cloud Messaging or Expo Push)  
- Production-grade logging and monitoring (Prometheus, Grafana)  

---

## Development Environment

- Python 3.10+ virtual environment  
- Node.js and npm (for React Native and Expo CLI)  
- Docker and Docker Compose installed locally  
- MongoDB Atlas cluster for production data  
- Linux VM or cloud instance for deployment testing  

---

## Summary of Tools

| Purpose               | Technology/Tool           |
|-----------------------|--------------------------|
| Frontend              | React Native (Expo)      |
| Backend               | FastAPI (Python)         |
| Database              | MongoDB Atlas            |
| Authentication        | JWT + OAuth2             |
| Real-time             | WebSocket (FastAPI/Starlette) |
| Containerization      | Docker                   |
| Deployment Automation | Ansible                  |
| CI/CD                 | GitHub Actions / GitLab CI |
| Testing               | Jest (frontend), Pytest (backend) |

---

## Data Models (Simplified)

```json
// User
{
  "_id": "ObjectId",
  "username": "string",
  "email": "string",
  "passwordHash": "string",
  "profileImageUrl": "string",
  "preferences": { /* user preferences */ },
  "createdAt": "Date"
}

// ContentItem
{
  "_id": "ObjectId",
  "type": "string", // e.g., recipe, travel, workout, movie
  "title": "string",
  "description": "string",
  "images": ["string"], // URLs
  "metadata": { /* flexible key-value pairs */ },
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
