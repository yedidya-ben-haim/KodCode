import pandas as pd


df = pd.read_csv("tracks.csv")


print(df["speed"].max())