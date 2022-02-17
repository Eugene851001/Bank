import logo from './logo.svg';
import './App.css';
import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Logination } from './Components/Logination';

function App() {
  return (
    <Router>
      <Route path="/" element={<Home/>} />
      <Route path="/login" element={<Logination/>} />
    </Router>
  );
}

export default App;
