from db.mongo import db
from models.user_model import User
from bson.objectid import ObjectId
from typing import Optional, List

class UserService:
    def __init__(self):
        self.collection = db["users"]

    async def create_user(self, user: User) -> str:
        user_dict = user.dict(by_alias=True)
        result = await self.collection.insert_one(user_dict)
        return str(result.inserted_id)

    async def get_by_username(self, username: str) -> Optional[User]:
        user = await self.collection.find_one({"username": username})
        if user:
            return User(**user)
        return None

    async def get_by_email(self, email: str) -> Optional[User]:
        user = await self.collection.find_one({"email": email})
        if user:
            return User(**user)
        return None

    async def get_all_users(self) -> List[User]:
        users = []
        async for user in self.collection.find():
            users.append(User(**user))
        return users
