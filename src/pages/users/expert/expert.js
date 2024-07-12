import { memo } from 'react';
import { getAllUsers } from '../../../api/accounts';
import { useState, useEffect } from 'react';
const ExpertUserView = () => {
  const [experts, setExperts] = useState([]);


  useEffect(() => {
    const fetchExperts = async () => {
        const data = await getAllUsers();
        setExperts(data);
    };
    fetchExperts();
  }, []);

  return (
    <div>
      <h2>Experts</h2>
      <div>Required Get User By Role</div>
    </div>
  );
}

export default memo(ExpertUserView);