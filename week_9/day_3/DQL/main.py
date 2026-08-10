from fastapi import FastAPI, Query
import queries

app = FastAPI()


@app.get("/soldiers")
def get_soldier_by_query(
        soldier_rank: str | None = Query(default=None),
        sort: str = Query(default="asc"),
        unit: str | None = Query(default=None)
):
        if soldier_rank:
                return {"soldiers": queries.get_by_rank(soldier_rank)}
        elif unit:
                return {"soldiers": queries.get_by_unit(unit)}
        return {"soldiers": queries.get_active_sorted(sort)}


@app.get("/soldiers/units")
def get_distinct_unit():
        return {"units": queries.get_distinct_units()}


@app.get("/soldiers/search")
def get_soldiers_by_name(name: str = Query()):
        return {"soldier": queries.search_by_name(name)}


@app.get("/soldiers/missing-rank")
def get_missing_rank_soldiers():
        return {"missing rank:": queries.get_missing_rank()}









