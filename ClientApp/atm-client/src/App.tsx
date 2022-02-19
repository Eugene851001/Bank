import {BrowserRouter as Router, Route, Routes } from 'react-router-dom'
import { Logination } from './Components/Logination';
import {Home} from './Components/Home';
import { store } from './Store/Store';
import {Provider} from 'react-redux';
import { MainContainer } from './Components/MainContainer';

function App() {
  return (
    <Provider store={store}>
        <MainContainer />
    </Provider>
  );
}

export default App;
