import React, { useState, useEffect } from "react";

function App() {
  const [members, setMembers] = useState([]);
  const [equipments, setEquipments] = useState([]);
  const [selectedMember, setSelectedMember] = useState("");
  const [selectedEquipment, setSelectedEquipment] = useState("");
  const [selectedDate, setSelectedDate] = useState("");
  const [selectedTimeSlot, setSelectedTimeSlot] = useState(1);

  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

  // Fetch members
  useEffect(() => {
    const fetchMembers = async () => {
      try {
        const response = await fetch("https://localhost:7293/api/Member/GetMembers");
        if (!response.ok) {
          throw new Error(`Failed to fetch members: ${response.status}`);
        }
        const data = await response.json();
        setMembers(data);
      } catch (err) {
        setError(err.message);
      }
    };
    fetchMembers();
  }, []);

  // Fetch equipment
  useEffect(() => {
    const fetchEquipments = async () => {
      try {
        const response = await fetch("https://localhost:7293/api/Equipment/GetEquipments");
        if (!response.ok) {
          throw new Error(`Failed to fetch equipments: ${response.status}`);
        }
        const data = await response.json();
        setEquipments(data.filter((equipment) => !equipment.inService)); // Filter "inService: false"
      } catch (err) {
        setError(err.message);
      }
    };
    fetchEquipments();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError(null);
    setSuccess(null);

    if (!selectedMember || !selectedEquipment || !selectedDate || !selectedTimeSlot) {
      setError("Please fill out all fields.");
      return;
    }

    const reservationData = {
      equipmentId: parseInt(selectedEquipment),
      timeSlotId: parseInt(selectedTimeSlot),
      date: selectedDate,
      memberId: parseInt(selectedMember),
    };

    try {
      const response = await fetch("https://localhost:7293/api/Reservation/NewReservation", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(reservationData),
      });

      if (!response.ok) {
        throw new Error(`Failed to create reservation: ${response.status}`);
      }

      setSuccess("Reservation created successfully!");
    } catch (err) {
      setError(err.message);
    }
  };

  return (
    <div style={{ padding: "20px", maxWidth: "500px", margin: "0 auto" }}>
      <h1>Create Reservation</h1>

      {error && <p style={{ color: "red" }}>{error}</p>}
      {success && <p style={{ color: "green" }}>{success}</p>}

      <form onSubmit={handleSubmit}>
        {/* Member Dropdown */}
        <label>
          Select Member:
          <select
            value={selectedMember}
            onChange={(e) => setSelectedMember(e.target.value)}
            required
          >
            <option value="">-- Choose a Member --</option>
            {members.map((member) => (
              <option key={member.memberId} value={member.memberId}>
                {member.firstName} {member.lastName}
              </option>
            ))}
          </select>
        </label>
        <br />

        {/* Equipment Dropdown */}
        <label>
          Select Equipment:
          <select
            value={selectedEquipment}
            onChange={(e) => setSelectedEquipment(e.target.value)}
            required
          >
            <option value="">-- Choose Equipment --</option>
            {equipments.map((equipment) => (
              <option key={equipment.equipmentId} value={equipment.equipmentId}>
                {equipment.deviceType}
              </option>
            ))}
          </select>
        </label>
        <br />

        {/* Date Picker */}
        <label>
          Select Date:
          <input
            type="date"
            value={selectedDate}
            onChange={(e) => setSelectedDate(e.target.value)}
            required
          />
        </label>
        <br />

        {/* Time Slot Dropdown */}
        <label>
          Select Time Slot:
          <select
            value={selectedTimeSlot}
            onChange={(e) => setSelectedTimeSlot(e.target.value)}
            required
          >
            {Array.from({ length: 14 }, (_, i) => i + 1).map((slot) => (
              <option key={slot} value={slot}>
                {slot}
              </option>
            ))}
          </select>
        </label>
        <br />

        <button type="submit" style={{ marginTop: "20px" }}>
          Create Reservation
        </button>
      </form>
    </div>
  );
}

export default App;
