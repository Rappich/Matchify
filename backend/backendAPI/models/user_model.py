from pydantic import BaseModel, EmailStr, Field
from typing import Optional
from datetime import datetime

# User model for MongoDB
class User(BaseModel):
    id: Optional[str] = Field(alias="_id") 
    username: str
    email: EmailStr
    password_hash: str
    created_at: datetime = Field(default_factory=datetime.utcnow)

# Pydantic models for user registration and login requests
class RegisterRequest(BaseModel):
    username: str
    email: EmailStr
    password: str

# Pydantic model for user login requests
class LoginRequest(BaseModel):
    username: str
    password: str
