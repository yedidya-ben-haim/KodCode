import mysql.connector


def get_connection():
    return mysql.connector.connect(user='root', password='secret',
                              host='127.0.0.1',
                              database='mydb')


def get_summary():
    """
        Return total active and unactive soldiers
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT COUNT(*) AS total FROM soldiers")
    total = cursor.fetchone()["total"]

    cursor.execute("SELECT COUNT(*) AS total_active FROM soldiers WHERE active = TRUE")
    total_active = cursor.fetchone()["total_active"]

    cursor.close()
    conn.close()

    return {"total": total, "active": total_active, "inactive": total-total_active}

def count_by_unit():
     """
        Return the num of soldiers on each unit
     """
     conn = get_connection()
     cursor = conn.cursor(dictionary=True)

     cursor.execute("""
        SELECT unit,COUNT(*) as total
        FROM soldiers
        GROUP BY unit
        ORDER BY total DESC
     """)
     rows = cursor.fetchall()

     conn.close()
     cursor.close()

     return rows

def get_missing_data():
    """
        Return soldiers with rank null
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("""
                    SELECT * FROM soldiers    
                    WHERE soldier_rank IS null
                    """)

    rows = cursor.fetchall()

    conn.close()
    cursor.close()

    return {"soldiers without rank": rows}

def get_units_with_multiple_soldiers():
    """
        Return soldiers with rank null
    """
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("""  SELECT unit, COUNT(*) as unit_count
                        FROM soldiers 
                        GROUP BY unit
                        HAVING unit_count > 1
                        """)

    rows = cursor.fetchall()

    conn.close()
    cursor.close()

    return rows

print(get_units_with_multiple_soldiers())