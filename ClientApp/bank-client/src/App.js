import logo from './logo.svg';
import './App.css';
import { Users } from './Components/Users';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { UserDetails } from './Components/UserDetails';
import { UserDetailsView } from './Components/UserDetailsView';
import { Accounts } from './Components/Accounts';
import { ContractsForm } from './Components/ContractsForm';
import { Deposits } from './Components/Deposits';
import { Deposit } from './Components/Deposit';
import { CurrentDateProvider } from './Contexts/CurrentDateContext';

function App() {
  return (
    <CurrentDateProvider>
      <Router>
        <Routes>
          <Route path="/" element={<Users/>}/>
          <Route path="/users/:userId" element={<UserDetails/>}/>
          <Route path="/users/create" element={<UserDetailsView/>}/>
          <Route path="/accounts" element={<Accounts/>}/>
          <Route path="/contracts/:userId" element={<ContractsForm/>}/>
          <Route path="/deposits" element={<Deposits />}/>
          <Route path="/deposits/:depositId" element={<Deposit />}/>
        </Routes>
      </Router>
    </CurrentDateProvider>  
  );
}

export default App;
