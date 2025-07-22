from pydantic import BaseModel, EmailStr, Field
from typing import Optional
from datetime import datetime

# User model definition.This model represents the user data structure used in the application.
class User(BaseModel):
    id: Optional[str] = Field(alias="_id")  # MongoDB ObjectId as string
    username: str
    email: EmailStr
    password_hash: str = Field(alias="passwordHash")
    created_at: datetime = Field(default_factory=datetime.utcnow, alias="createdAt")

    # Pydantic configuration to allow population by field names and aliases
    class Config:
        allow_population_by_field_name = True  

# Request models for user registration and login
# These models are used to validate incoming data for user registration and login requests.
class RegisterRequest(BaseModel):
    username: str
    email: EmailStr
    password: str

# Login request model
# This model is used to validate incoming data for user login requests.
class LoginRequest(BaseModel):
    username: str
    password: str
