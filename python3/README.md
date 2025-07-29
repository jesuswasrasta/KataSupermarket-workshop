# Kata Supermarket - Python3 Edition

See [kata README](../README.md) for the exercise explanation.

## Setup

### 1. Create and activate virtual environment
```bash
cd python3
python -m venv .venv

# On Windows
.venv\Scripts\activate

# On macOS/Linux
source .venv/bin/activate
```

### 2. Install dependencies
```bash
pip install -e ".[test]"
```

### 3. Run tests
```bash
pytest
```

### 4. Run tests with verbose output
```bash
pytest -v
```

### 5. Run tests with coverage
```bash
pytest --cov=src
```
