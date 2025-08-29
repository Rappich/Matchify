# Git Hooks Setup for Matchify

This document explains how to set up and use the shared git hooks for this project.

---

## 1. Set up hooks path

After cloning the repository, run:

git config core.hooksPath .githooks
This tells Git to use the hooks stored in .githooks/ instead of the default .git/hooks.

## 2. Make hooks executable
bash
Copy code
chmod +x .githooks/*
This ensures that all hooks can be executed automatically.

## 3. Setup backend virtual environment

cd backend/backendAPI
python -m venv venv
source venv/bin/activate
pip install -r requirements.txt

This ensures that black, flake8, and detect-secrets are available in your local environment.

## 4. How hooks work
pre-commit: runs Black (Python formatting), Flake8 (Python linting), detect-secrets (detect API keys), and ESLint (frontend linting).

commit-msg: enforces conventional commit messages.

pre-push (optional): can be used for additional checks before pushing.

## 5. Updating hooks
If hooks are updated in the repository:

git pull
chmod +x .githooks/*
This ensures you are always using the latest version.

## 6. Notes for team members
Make sure your virtual environment is activated when working with backend hooks.

All hook scripts are located in .githooks/.

If you encounter permission errors, double-check that the hooks are executable.
