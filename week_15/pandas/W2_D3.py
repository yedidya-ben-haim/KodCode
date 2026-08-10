import pandas as pd


# # step 2
# track_id = [1, 2, 3, 4]
# speed = [412, 95, 250, 510]
#
# my_series = pd.Series(speed, index=track_id)
#
# print(my_series)

# step 3
data = {
    "id": ["T101", "T102", "T103", "T104"],
    "speed": [412, 95, 250, 510],
    "heading": ["North", "East", "South", "West"]
}

df = pd.DataFrame(data)

# print(df)
# print(df["speed"])

# step 4
# df.set_index(["id"])
#
# df["speed_kmh"] = df["speed"] * 1.852
#
# print(df)


