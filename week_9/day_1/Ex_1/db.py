import mysql.connector

def get_connection():
    return mysql.connector.connect(
        host="localhost",
        port=3306,
        user="root",
        password= "secret",
        database="mydb"
    )


def get_schema():

    conn = get_connection()
    cursor = conn.cursor()

    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return [{"column": row[0], "type": row[1]} for row in rows]



