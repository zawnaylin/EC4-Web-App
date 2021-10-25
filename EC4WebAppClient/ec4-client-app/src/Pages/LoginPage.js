import LoginForm from "../Components/LoginForm/LoginForm";

const LoginPage = ({ setName }) => {

  return (
    <div className="text-center">
      <LoginForm setName={setName} />
    </div>
  );
}

export default LoginPage;