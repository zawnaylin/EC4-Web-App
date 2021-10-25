import { Switch, Route } from "react-router-dom";
import { useState } from "react/cjs/react.development";
import Navbar from './Components/Navbar/Navbar';
import HomePage from "./Pages/HomePage";
import LoginPage from "./Pages/LoginPage";

function App() {
  const [name, setName] = useState("");

  return (
    <div className="App">
      <Navbar name={name} setName={setName} />
      <Switch>
        <Route strict exact path="/">
          <HomePage />
        </Route>
        <Route strict exact path="/login">
          <LoginPage setName={setName}  />
        </Route>
      </Switch>
    </div>


  );
}

export default App;
