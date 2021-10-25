const ErrorsList = ({ errors }) => {
  return (
    <div className="errors-list">
      <span>Login failed</span>
      <ul>
        {errors.map((error, index) => <li key={index}>{error}</li>)}
      </ul>
    </div>
  );
}

export default ErrorsList;