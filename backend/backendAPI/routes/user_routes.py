from fastapi import APIRouter, HTTPException
from models.user_model import User, RegisterRequest, LoginRequest
from services.user_service import UserService
from utils.hash import hash_password, verify_password
from datetime import datetime

router = APIRouter(prefix="/api", tags=["Users"])
user_service = UserService()

@router.post("/register")
async def register_user(request: RegisterRequest):
    existing_email = await user_service.get_by_email(request.email)
    existing_username = await user_service.get_by_username(request.username)

    if existing_email or existing_username:
        raise HTTPException(status_code=400, detail="User already exists")

    hashed_pw = hash_password(request.password)

    new_user = User(
        username=request.username,
        email=request.email,
        password_hash=hashed_pw,
        created_at=datetime.utcnow()
    )

    user_id = await user_service.create_user(new_user)
    return {"message": "User registered", "user_id": user_id}

@router.post("/login")
async def login_user(request: LoginRequest):
    user = await user_service.get_by_username(request.username)
    if user is None or not verify_password(request.password, user.password_hash):
        raise HTTPException(status_code=401, detail="Invalid credentials")

    return {"message": "Login successful", "username": user.username}

@router.get("/Users")
async def list_users():
    users = await user_service.get_all_users()
    return users
