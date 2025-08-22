import pytest
from httpx import AsyncClient
from httpx import ASGITransport
from main import app

@pytest.mark.asyncio
async def test_register_user():
    transport = ASGITransport(app=app)
    async with AsyncClient(transport=transport, base_url="http://test") as client:

        data = {            "username": "testuser4",
            "email": "testuser@example.com",
            "password": "password123"
            }
        response = await client.post("/api/register", json=data)
        assert response.status_code == 200
        assert "user_id" in response.json()
