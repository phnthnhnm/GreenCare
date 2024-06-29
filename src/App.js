import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Home } from './component/Home/Home';
import { LoginRegister } from './component/Register/LoginRegister';
import { Admin } from './component/Admin/Admin';
import { Manager } from './component/Manager/Manager';
import { Employee } from './component/Employee/Employee';
import { Customer } from './component/Customer/Customer';

const App = () => (
  <Router>
    <div>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<LoginRegister />} />
        <Route path="/admin" element={<Admin />} />
        <Route path="/manager" element={<Manager />} />
        <Route path="/employee" element={<Employee />} />
        <Route path="/customer" element={<Customer />} />
      </Routes>
    </div>
  </Router>
);

export default App;