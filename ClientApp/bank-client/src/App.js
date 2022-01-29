import logo from './logo.svg';
import './App.css';
import { Users } from './Components/Users';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { UserDetails } from './Components/UserDetails';
import { UserDetailsView } from './Components/UserDetailsView';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Users/>}/>
        <Route path="/users/:userId" element={<UserDetails/>}/>
        <Route path="/users/create" element={<UserDetailsView/>}/>
      </Routes>
    </Router>
  );
}

export default App;
