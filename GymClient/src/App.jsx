import { useState, useEffect } from "react";
import "./App.css"; // Import de CSS

function App() {
  const [members, setMembers] = useState([]);
  const [equipments, setEquipments] = useState([]);
  const [selectedMember, setSelectedMember] = useState("");
  const [selectedEquipment, setSelectedEquipment] = useState("");
  const [selectedDate, setSelectedDate] = useState("");
  const [selectedTimeSlot, setSelectedTimeSlot] = useState(1);

  const [error, setError] = useState(null);
  const [success, setSuccess] = useState(null);

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

  useEffect(() => {
    const fetchEquipments = async () => {
      try {
        const response = await fetch("https://localhost:7293/api/Equipment/GetEquipments");
        if (!response.ok) {
          throw new Error(`Failed to fetch equipments: ${response.status}`);
        }
        const data = await response.json();
        setEquipments(data.filter((equipment) => !equipment.inService));
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
    <div className="container">
      <h1 className="heading">YouMove</h1>
      <h2 className="subHeading">Reservation Service</h2>

      {error && <p className="error">{error}</p>}
      {success && <p className="success">{success}</p>}

      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label className="label">Select Member:</label>
          <select
            className="select"
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
        </div>

        <div className="form-group">
          <label className="label">Select Equipment:</label>
          <select
            className="select"
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
        </div>

        <div className="form-group">
          <label className="label">Select Date:</label>
          <input
            type="date"
            className="input"
            value={selectedDate}
            onChange={(e) => setSelectedDate(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label className="label">Select Time Slot:</label>
          <select
            className="select"
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
        </div>

        <button type="submit" className="button">
          Create Reservation
        </button>
      </form>
    </div>
  );
}

export default App;
