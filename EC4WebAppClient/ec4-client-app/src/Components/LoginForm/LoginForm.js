import { useState } from "react";
import { useHistory } from "react-router-dom";
import ErrorsList from "../ErrorsList/ErrorsList";
import './LoginForm.css';

const LoginForm = ({ setName }) => {

  const [userName, setUserName] = useState("");
  const [password, setPassword] = useState("");
  const [rememberMe, setRememberMe] = useState(false);
  const [errors, setErrors] = useState([]);
  const history = useHistory();

  const submitHandler = async (e) => {
    e.preventDefault();
    // try {
    const response = await fetch("https://localhost:5001/api/v1/identity/login", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      credentials: 'include',
      body: JSON.stringify({
        userName, password
      })
    });

    if (response.status >= 400 && response.status < 500) {
      const apiError = await response.json();
      setErrors(apiError.errors);

    } else {
      const data = await response.json();
      setName(data.displayName);
      history.push("/");
    }
    
    // history.goBack();
    // } catch (ex) {

    // }
  }


  return (
    <div className="form-signin">
      {errors && <ErrorsList errors={errors} />}
      <form onSubmit={submitHandler}>
        <h1 className="h3 mb-3 fw-normal">Please sign in</h1>
        <div className="form-floating">
          <input
            type="text"
            className="form-control"
            id="floatingInput"
            placeholder="username"
            onChange={e => setUserName(e.target.value)} />
          <label htmlFor="floatingInput">Username</label>
        </div>
        <div className="form-floating">
          <input
            type="password"
            className="form-control"
            id="floatingPassword"
            placeholder="password"
            onChange={e => setPassword(e.target.value)} />
          <label htmlFor="floatingPassword">Password</label>
        </div>
        <div className="checkbox mb-3">
          <label>
            <input type="checkbox" value="remember-me" checked={rememberMe} onChange={() => setRememberMe(!rememberMe)} /> Remember me
          </label>
        </div>
        <button
          className="w-100 btn btn-lg btn-primary"
          type="submit">Sign in</button>
      </form>
    </div>
  );
}

export default LoginForm;