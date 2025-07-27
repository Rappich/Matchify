from pydantic import BaseModel, EmailStr, Field
from typing import Optional
from datetime import datetime

# User model definition. Represents the user data structure in the application.
class User(BaseModel):
    # MongoDB ObjectId represented as a string with alias '_id'
    id: Optional[str] = Field(default=None, alias="_id")
    username: str
    email: EmailStr
    # Password hash field with exact alias to match database key 'passwordHash'
    passwordHash: str = Field(..., alias="passwordHash")
    # Timestamp for when the user was created, with default set to current UTC time
    createdAt: datetime = Field(default_factory=datetime.utcnow, alias="createdAt")

    class Config:
        # Allows population of the model using either field names or aliases
        allow_population_by_field_name = True

# Request model for user registration. Used to validate registration input data.
class RegisterRequest(BaseModel):
    username: str
    email: EmailStr
    password: str

# Request model for user login. Used to validate login input data.
class LoginRequest(BaseModel):
    username: str
    password: str
