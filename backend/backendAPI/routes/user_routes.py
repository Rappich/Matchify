from fastapi import APIRouter, HTTPException
from models.user_model import User, RegisterRequest, LoginRequest
from services.user_service import UserService
from utils.hash import hash_password, verify_password
from datetime import datetime, timedelta
from utils.jwt import create_access_token

router = APIRouter(prefix="/api", tags=["Users"])
user_service = UserService()

# User registration endpoint
@router.post("/register")
async def register_user(request: RegisterRequest):
    # Check if user with email or username already exists
    existing_email = await user_service.get_by_email(request.email)
    existing_username = await user_service.get_by_username(request.username)
    if existing_email or existing_username:
        raise HTTPException(status_code=400, detail="User already exists")

    # Hash the password
    hashed_pw = hash_password(request.password)

    # Create new user with correct field names matching User model (using aliases)
    new_user = User(
        username=request.username,
        email=request.email,
        passwordHash=hashed_pw,  # use alias name
        createdAt=datetime.utcnow()  # use alias name
    )

    # Save user and get id
    user_id = await user_service.create_user(new_user)

    return {"message": "User registered", "user_id": user_id}

# User login endpoint
@router.post("/login")
async def login_user(request: LoginRequest):
    user = await user_service.get_by_username(request.username)
    if user is None or not verify_password(request.password, user.passwordHash):
        raise HTTPException(status_code=401, detail="Invalid credentials")

    access_token = create_access_token(
        data={"sub": user.username},
        expires_delta=timedelta(minutes=60)
    )

    return {
        "access_token": access_token,
        "token_type": "bearer",
        "username": user.username
    }

# List all users endpoint
@router.get("/users")
async def list_users():
    users = await user_service.get_all_users()
    # Return user data with field aliases (_id, passwordHash, createdAt)
    return [user.dict(by_alias=True) for user in users]
