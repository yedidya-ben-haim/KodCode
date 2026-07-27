import mysql.connector

def get_connection():
    return mysql.connector.connect(
        host="localhost",
        port=3306,
        user="root",
        password= "secret",
        database="mydb"
    )

def get_all() ->list:
    """
        Return all soldiers
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers")
    row = cursor.fetchall()

    cursor.close()
    conn.close()

    return row


def get_by_id(soldier_id: int) ->dict | None:
    """
        Return soldier by ID
    """
    conn = get_connection()
    cursor =  conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE id = %s", (soldier_id,))
    row = cursor.fetchone()

    cursor.close()
    conn.close()

    return row


def create(name: str, rank: str, unit: str) -> int:
    conn = get_connection()
    cursor = conn.cursor()

    sql = "INSERT INTO soldiers (name, soldier_rank, unit) VALUES (%s, %s, %s)"
    values = (name, rank, unit)

    cursor.execute(sql, values)
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()
    return new_id


def update(soldier_id: int, data: dict) -> bool:
    conn = get_connection()
    cursor = conn.cursor()

    set_parts = [f"{key} = %s" for key in data.keys()]
    set_claus = ", ".join(set_parts)

    sql =f"UPDATE soldiers SET {set_claus} WHERE id = %s"
    values = list(data.values()) + [soldier_id]

    cursor.execute(sql, values)
    conn.commit()

    updated = cursor.rowcount > 0

    cursor.close()
    conn.close()

    return updated

def delete(soldier_id: int) ->bool:
    conn = get_connection()
    cursor = conn.cursor()

    cursor.execute("DELETE FROM soldiers WHERE id = %s", (soldier_id,))
    conn.commit()

    deleted = cursor.rowcount > 0

    cursor.close()
    conn.close()

    return deleted


