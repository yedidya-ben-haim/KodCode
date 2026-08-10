import mysql.connector

from day_2.db import update


class IntelMessagesDAL:
    VALID_CLASSIFICATIONS = ('unclassified', 'confidential', 'secret', 'top_secret')

    def __init__(self, host: str, user: str, password: str, database: str):
        """
            Store connection parameters on self
            Open a single connection and store it on self
            Store a cursor (dictionary=True) on self
        """
        self.host = host
        self.user = user
        self.password = password
        self.database = database

        self.connection = mysql.connector.connect(
            host=self.host,
            port=3306,
            user=self.user,
            password=self.password,
            database= self.database
        )
        self.cursor = self.connection.cursor(dictionary=True)


    def setup(self) -> None:
        """
            Create the intel_messages table if it does not exist
            Column definitions: id, unit, classification (ENUM), content, source, created_at
            Commit after execution
        """
        query = """CREATE TABLE IF NOT EXIST intel_messages(
            id INT AUTO_INCREMENT PRIMARY KEY,
                unit VARCHAR(100) NOT NULL,
                classification ENUM('unclassified', 'confidential', 'secret', 'top_secret') NOT NULL,
                content TEXT NOT NULL,
                source VARCHAR(100) DEFAULT NULL,
                created_at DATETIME DEFAULT NOW()
            );
            """
        self.cursor.execute(query)
        self.connection.commit()


    def get_schema(self) -> list[dict]:
        """
            Query INFORMATION_SCHEMA.COLUMNS for the intel_messages table
            Return a list of dicts: [{"column": ..., "type": ...}, ...]
        """
        query = """
                SELECT COLUMN_NAME, DATA_TYPE
                FROM INFORMATION_SCHEMA.COLUMNS
                WHERE TABLE_SCHEMA = %s AND TABLE_NAME = 'intel_messages';
                """
        self.cursor.execute(query, (self.database,))
        rows = self.cursor.fetchall()
        return [{"column": row["COLUMN_NAME"], "type": row["DATA_TYPE"]} for row in rows]

    def get_all(self) -> list[dict]:
        """
            Return every row in intel_messages as a list of dicts
        """
        self.cursor.execute("SELECT * FROM intel_messages")
        return self.cursor.fetchall()

    def get_by_id(self, message_id: int) -> dict | None:
        """
            Return the single row where id matches message_id, or None if not found
        """

        query = "SELECT * FROM intel_messages WHERE id = %s"
        self.cursor.execute(query, (message_id,))
        row = self.cursor.fetchone()
        return row

    def create(self, unit: str, classification: str, content: str, source: str | None) -> int:
        """
        Insert a new row (do NOT pass created_at, let MySQL set it)
        Commit the transaction
        Return the auto-generated id (lastrowid)
        """
        query = """
                INSERT INTO intel_messages (unit, classification, content, source) VALUES(%s, %s, %s, %s)
                """
        self.cursor.execute(query, (unit, classification, content, source))
        self.connection.commit()
        last_id = self.cursor.lastrowid

        return last_id

    def update(self, message_id: int, data: dict) -> bool:
        """
            Build a dynamic SET clause from the keys in data
            Only update the columns that are present in data
            Commit the transaction
            Return True if a row was changed, False if the id did not exist
            Never use f-strings for values, only %s
        """
        if not data:
            return False

        in_part = [f"{key}= %s" for key in data.keys()]
        in_str = ", ".join(in_part)
        update_date = list(data.values()) + [message_id]

        query = f"UPDATE intel_messages SET {in_str} WHERE id = %s"
        self.cursor.execute(query, update_date)
        self.connection.commit()

        updated = self.cursor.rowcount > 0
        return updated





    def delete(self, message_id: int) -> bool:
        # Delete the row where id matches message_id [cite: 97, 99]
        # Commit the transaction [cite: 98]
        # Return True if a row was deleted, False if the id did not exist [cite: 100]
        pass

    def get_by_unit(self, unit: str) -> list[dict]:
        # All messages where unit matches, ordered by created_at DESC [cite: 103]
        pass

    def get_by_classification(self, classification: str) -> list[dict]:
        # All messages at the given classification level [cite: 106]
        pass

    def get_by_unit_and_classification(self, unit: str, classification: str) -> list[dict]:
        # Both filters combined with AND [cite: 108]
        pass

    def get_distinct_units(self) -> list[str]:
        # All unique unit values [cite: 110]
        # return a plain list of strings, not dicts [cite: 111]
        pass

    def search_content(self, term: str) -> list[dict]:
        # Rows where content contains term (partial match) [cite: 113]
        pass

    def get_missing_source(self) -> list[dict]:
        # Rows where source IS NULL [cite: 115]
        pass

    def close(self) -> None:
        # Close the cursor and the connection [cite: 119]
        pass


dal = IntelMessagesDAL("localhost","root","secret", "mydb")
print(dal.update(1, {"unit": 80, "classification": "secret"}))
