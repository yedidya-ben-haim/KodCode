import mysql.connector



def get_connection():
    return mysql.connector.connect(
        user = "root",
        password = "secret",
        host = "localhost",
        port = 3306,
        database = "mydb"
    )


def get_by_rank(rank):
    """
        Return list of soldiers by rank
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE soldier_rank = %s", (rank,))
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows

def get_active_sorted(order: str = "asc") -> list:
    """
        Return active soldiers ordered
    """
    if order.lower() not in ("asc", "desc"):
        order = "asc"

    conn = get_connection()
    cursor = conn.cursor(dictionary=True)



    cursor.execute(f"SELECT * FROM soldiers WHERE active=TRUE ORDER BY name {order.upper()}")
    rows = cursor.fetchall()

    conn.close()
    cursor.close()

    return rows

def get_distinct_units() -> list:
    """
        Return unit distinct
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT DISTINCT unit FROM soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows

def search_by_name(term):
    """
        Return soldiers by name
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE name LIKE %s", (term,))
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows

def get_missing_rank():
    """
        Return rows with missing rank
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE soldier_rank IS NULL")
    rows = cursor.fetchall()

    conn.close()
    cursor.close()

    return rows

def get_by_unit(unit):
    """
        Return soldiers by unit
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE unit = %s ORDER BY name ASC", (unit,))
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows