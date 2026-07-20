import pandas as pd

# Step 1 — A frame with several numeric columns

data = {
    "id": [101, 102, 103, 104, 105],
    "speed": [120, 95, 140, 110, 160],
    "altitude": [1000, 850, 1200, 950, 1500],
    "distance": [15, 12, 20, 14, 25]
}

df = pd.DataFrame(data)

print(df)

# Step 2 — One big summary.
print(df.describe())


# Step 3 — Single statistics per column
speed_avg = df["speed"].mean()
altitude_med = df["altitude"].median()
distance_max = df["distance"].max()
distance_min = df["distance"].min()
speed_count = df["speed"].count()

print("Speed mean:", speed_avg)
print("Altitude median:", altitude_med)
print("Distance max:", distance_max)
print("Distance min:", distance_min)
print("Speed count:", speed_count)

# Step 4 — Read the numbers
