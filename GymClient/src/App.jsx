import React, { useEffect, useState } from "react";

function App() {
  const [members, setMembers] = useState([]);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchMembers = async () => {
      try {
        const response = await fetch("https://localhost:7293/api/Member/GetMembers");
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        setMembers(data); // Zet de opgehaalde data in state
      } catch (err) {
        setError(err.message);
      }
    };

    fetchMembers();
  }, []);

  return (
    <div>
      <h1>Members</h1>
      {error ? (
        <p style={{ color: "red" }}>Error: {error}</p>
      ) : (
        <ul>
          {members.map((member) => (
            <li key={member.memberId}>
              <strong>Name:</strong> {member.firstName} {member.lastName} <br />
              <strong>Email:</strong> {member.email} <br />
              <strong>Address:</strong> {member.address} <br />
              <strong>Birthday:</strong> {new Date(member.birthday).toLocaleDateString()}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
}

export default App;
