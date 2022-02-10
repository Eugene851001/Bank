import logo from './logo.svg';
import './App.css';
import { Users } from './Components/Users';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { UserDetails } from './Components/UserDetails';
import { UserDetailsView } from './Components/UserDetailsView';
import { Accounts } from './Components/Accounts';
import { Deposits } from './Components/Deposits';
import { Deposit } from './Components/Deposit';
import { CurrentDateProvider } from './Contexts/CurrentDateContext';
import { DepositForm } from './Components/DepositForm';
import { CreditForm } from './Components/CreditForm';
import {Credits} from './Components/Credits';
import {Credit} from './Components/Credit';


function App() {
  return (
    <CurrentDateProvider>
      <Router>
        <Routes>
          <Route path="/" element={<Users/>}/>
          <Route path="/users/:userId" element={<UserDetails/>}/>
          <Route path="/users/create" element={<UserDetailsView/>}/>
          <Route path="/accounts" element={<Accounts/>}/>
          <Route path="/depositForm/:userId" element={<DepositForm/>}/>
          <Route path="/creditForm/:userId" element={<CreditForm />}/>
          <Route path="/deposits" element={<Deposits />}/>
          <Route path="/deposits/:depositId" element={<Deposit />}/>
          <Route path="/credits" element={<Credits/>}/>
          <Route path="/credits/:creditId" element={<Credit/>}/>
        </Routes>
      </Router>
    </CurrentDateProvider>  
  );
}

export default App;
