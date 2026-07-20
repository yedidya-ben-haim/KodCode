import pandas as pd


data = {
    "id": [101, 102, 103, 103, 104],
    "date": [
        "2026-07-01",
        "2026-07-01",
        "2026-07-02",
        "2026-07-02",
        "2026-07-03"
    ],
    "amount": ["120", "85", "200", "200", "150"],
    "category": ["Food", "Travel", "Shopping", "Shopping", "Food"],
    "junk_column": ["x", "x", "x", "x", "x"]
}

df = pd.DataFrame(data)

# Step 2 — Deleting
# print(df.duplicated())
#
# df.drop_duplicates(inplace=True)
#
# print(df.duplicated())

# Step 3 — Data types

# print(df.dtypes)
#
#
# df["amount"] = pd.to_numeric(df["amount"])
#
# print(df.dtypes)

# Step 4 — Time Series
df["date"] = pd.to_datetime(df["date"])

print(df.dtypes)

df = df.set_index("date")

rows_per_day = df.resample("D").size()

print(df)
print(rows_per_day)



