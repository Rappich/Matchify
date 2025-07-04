# Project Roadmap

## Milestone 1: Project Setup & Basic Infrastructure
- [ ] Set up project repository on **GitHub** or **GitLab**  
  - Initialize Git repository  
  - Create `.gitignore` and basic README  
- [ ] Initialize React Native app with **Expo**  
- [ ] Set up ASP.NET Core Web API project  
- [ ] Configure **MongoDB Atlas** cluster and connect backend  
- [ ] Implement basic user registration and login API with **JWT authentication**  
- [ ] Build simple login and registration screens in React Native  
- [ ] Set up basic **Linux** environment (local VM or cloud) for development and deployment practice

## Milestone 2: Version Control & CI/CD Pipeline Setup
- [ ] Learn and practice **GitLab CI/CD** or **GitHub Actions** basics  
- [ ] Create simple pipeline that runs on each commit:  
  - Build backend API  
  - Run backend tests (start with simple unit tests)  
  - Build React Native app (or run lint/static analysis)  
- [ ] Containerize backend using **Docker**  
  - Write Dockerfile for ASP.NET Core API  
  - Build and run container locally  
- [ ] Set up Docker Compose for running backend + MongoDB locally  
- [ ] Write basic **Bash** or **Python** scripts to automate common tasks (build, test, deploy)

## Milestone 3: Content Management & Swipe UI
- [ ] Design and implement `ContentItem` data model and API endpoints (CRUD)  
- [ ] Create UI to fetch and display swipeable content cards in React Native  
- [ ] Implement swipe gestures (left/right) for content cards  
- [ ] Store user swipe actions in backend (API and MongoDB)  
- [ ] Extend CI/CD pipeline to build and test changes including new API endpoints

## Milestone 4: Real-Time Match Engine & Notifications
- [ ] Implement backend logic to detect matches when two users swipe right on the same content  
- [ ] Set up **SignalR** hub in ASP.NET Core for real-time notifications  
- [ ] Integrate SignalR client in React Native app to receive match notifications  
- [ ] Display match screen/notification instantly when a match occurs  
- [ ] Add automated integration tests to verify match and notification flows

## Milestone 5: Infrastructure Automation & Configuration Management
- [ ] Learn basics of **Ansible** for provisioning and configuration  
- [ ] Write simple Ansible playbooks to set up Linux server environment (install Docker, .NET runtime, MongoDB client, etc.)  
- [ ] Automate deployment of Docker containers to a test server using Ansible  
- [ ] Integrate Ansible deployment steps with CI/CD pipeline for smoother releases

## Milestone 6: Content Upload & User Profiles
- [ ] Implement content upload functionality with image handling in backend  
- [ ] Secure upload endpoints with authentication  
- [ ] Allow users to edit and delete their uploaded content  
- [ ] Build user profile screens in React Native (show info, preferences, uploaded content)  
- [ ] Update CI/CD pipeline to run end-to-end tests including content upload flows

## Milestone 7: External API Integration & Performance Optimization
- [ ] Research and integrate one or more external content APIs (optional)  
- [ ] Normalize external content data to fit platform’s data model  
- [ ] Implement paging, filtering in content API and frontend  
- [ ] Optimize database queries and backend performance  
- [ ] Monitor pipeline and deployment logs for errors/performance issues

## Milestone 8: Testing, Monitoring & Production Deployment
- [ ] Write comprehensive unit, integration, and UI tests for frontend and backend  
- [ ] Test real-time functionality under multi-user scenarios  
- [ ] Set up logging, monitoring, and alerts (basic tools or cloud provider services)  
- [ ] Prepare app for production deployment:  
  - Build and sign React Native app for stores (optional)  
  - Deploy backend API and MongoDB to a cloud provider (Azure, AWS, or DigitalOcean)  
  - Use Docker and Ansible for repeatable, automated deployments  
- [ ] Final polish and bug fixing

---
