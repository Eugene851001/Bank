import logo from './logo.svg';
import './App.css';
import { Users } from './Components/Users';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { UserDetails } from './Components/UserDetails';
import { UserDetailsView } from './Components/UserDetailsView';
import { Accounts } from './Components/Accounts';
import { ContractsForm } from './Components/ContractsForm';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Users/>}/>
        <Route path="/users/:userId" element={<UserDetails/>}/>
        <Route path="/users/create" element={<UserDetailsView/>}/>
        <Route path="/accounts" element={<Accounts/>}/>
        <Route path="/contracts" element={<ContractsForm/>}/>
      </Routes>
    </Router>
  );
}

export default App;
