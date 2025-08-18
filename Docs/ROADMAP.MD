# Project Roadmap

## Milestone 1: Project Setup & Basic Infrastructure
- [x] Set up project repository on **GitHub** or **GitLab**  
  - [x] Initialize Git repository  
  - [x] Create `.gitignore` and basic README  
- [x] Initialize React Native app with **Expo**  
- [x] Set up Python backend project with **FastAPI**  
- [x] Configure **MongoDB Atlas** cluster and connect backend  
- [x] Implement basic user registration and login API with **JWT authentication**  
- [x] Build simple login and registration screens in React Native
  - [ ] (optional) Implement **expo-router** for navigation or stay with stack navigation
  - [ ] (optional) Set up **nativewind** for styling and Tailwind support  
- [x] Set up basic **Linux** environment (local VM or cloud) for development and deployment practice  
- [ ] Review the **OSI model** and understand where HTTP, TCP, UDP fit  
- [ ] Practice using Linux networking tools (`ping`, `traceroute`, `nslookup`, `dig`, `netstat`, `ss`, `curl`)  

## Milestone 2: Version Control & CI/CD Pipeline Setup
- [ ] Learn and practice **GitLab CI/CD** or **GitHub Actions** basics  
- [ ] Create simple pipeline that runs on each commit:  
  - [ ] Build backend API  
  - [ ] Run backend tests (start with simple unit tests)  
  - [ ] Build React Native app (or run lint/static analysis)  
- [ ] Containerize backend using **Docker**  
  - [ ] Write Dockerfile for Python FastAPI backend  
  - [ ] Build and run container locally  
- [ ] Set up Docker Compose for running backend + MongoDB locally  
- [ ] Write basic **Bash** or **Python** scripts to automate common tasks (build, test, deploy)  
- [ ] Learn **IPv4 addressing** and **CIDR notation** (subnetting basics)  
- [ ] Understand **TCP vs UDP** and how it applies in CI/CD (e.g., API tests, service connectivity)  

## Milestone 3: Content Management & Swipe UI
- [ ] Design and implement `ContentItem` data model and API endpoints (CRUD)  
- [ ] Create UI to fetch and display swipeable content cards in React Native  
- [ ] Implement swipe gestures (left/right) for content cards  
- [ ] Store user swipe actions in backend (API and MongoDB)  
- [ ] Extend CI/CD pipeline to build and test changes including new API endpoints  
- [ ] Continue JWT implementation  
  - [ ] Add logic to extract and validate JWT from `Authorization: Bearer <token>` headers  
  - [ ] Implement `get_current_user()` dependency function  
  - [ ] Secure sensitive endpoints (e.g., swipe, profile) using `Depends(get_current_user)`  
  - [ ] Return appropriate 401/403 responses for invalid or missing tokens  
  - [ ] Create a simple `/me` endpoint to return current logged-in user's data  
- [ ] Explore how **DNS resolution** works when backend API is called (test with `dig`, `nslookup`)  
- [ ] Review how **HTTP/HTTPS** fits into the OSI model for APIs  

## Milestone 4: Real-Time Match Engine & Notifications
- [ ] Implement backend logic to detect matches when two users swipe right on the same content  
- [ ] Set up **WebSocket** (FastAPI built-in or third-party like `websockets`) for real-time notifications  
- [ ] Integrate WebSocket client in React Native app to receive match notifications  
- [ ] Display match screen/notification instantly when a match occurs  
- [ ] Add automated integration tests to verify match and notification flows  
- [ ] Compare **WebSockets (TCP-based)** vs **UDP-based** real-time communication approaches  
- [ ] Test firewall/port access for WebSocket connections  

## Milestone 5: Infrastructure Automation & Configuration Management
- [ ] Learn basics of **Ansible** for provisioning and configuration  
- [ ] Write simple Ansible playbooks to set up Linux server environment (install Docker, Python runtime, MongoDB client, etc.)  
- [ ] Automate deployment of Docker containers to a test server using Ansible  
- [ ] Integrate Ansible deployment steps with CI/CD pipeline for smoother releases  
- [ ] Learn basics of **DHCP** and how IPs are assigned in networks  
- [ ] Configure basic **firewall rules** on Linux VM (allow SSH, block unused ports, allow app traffic)  

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
- [ ] Test **DNS misconfigurations** and how they affect external API integration  
- [ ] Simulate **firewall restrictions/blocked ports** and troubleshoot connectivity  

## Milestone 8: Testing, Monitoring & Production Deployment
- [ ] Write comprehensive unit, integration, and UI tests for frontend and backend  
- [ ] Test real-time functionality under multi-user scenarios  
- [ ] Set up logging, monitoring, and alerts (basic tools or cloud provider services)  
- [ ] Prepare app for production deployment:  
  - [ ] Build and sign React Native app for stores (optional)  
  - [ ] Deploy backend API and MongoDB to a cloud provider (Azure, AWS, or DigitalOcean)  
  - [ ] Use Docker and Ansible for repeatable, automated deployments  
- [ ] Final polish and bug fixing  
- [ ] Verify **DNS setup and SSL certificates** for production domain  
- [ ] Test **firewall rules and load balancer configuration** in the cloud environment  
