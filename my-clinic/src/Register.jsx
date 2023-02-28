import React, {useState,setState, useEffect} from 'react';
import './Register.css'
function RegistrationForm() {
    
    const [firstName, setFirstName] = useState(null);
    const [secondName, setSecondName] = useState(null);
    const [lastName, setLastName] = useState(null);
    const [email, setEmail] = useState(null);
    const [emailDirty, setEmailDirty] = useState(false);
    const [password,setPassword] = useState(null);
    const [passwordDirty, setPasswordDirty] = useState(false);
    const [confirmPassword,setConfirmPassword] = useState(null);
    const [emailError, setEmailError] = useState('Email не може бути пустим');
    const [passwordError, setPasswordError] = useState('Пароль не може бути пустим');
    const [firstNameError, setFirstNameError] = useState('Ім\'я не може бути пустим'); 
    const [secondNameError, setSecondNameError] = useState('Прізвище не може бути пустим'); 
    const [lastNameError, setLastNameError] = useState('По-батькові не може бути пустим');
    const [firstNameDirty, setFirstNameDirty] = useState(false); 
    const [secondNameDirty, setSecondNameDirty] = useState(false); 
    const [lastNameDirty, setLastNameDirty] = useState(false);  
    const re =  /^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i;
    const pas = /^(?=.*[A-Z])(?=.*[0-9])(?=.*[^\w\s]).{6,}/
    const [formValid, setFormValid]=useState(false);

    useEffect(()=>{
        if(emailError||passwordError){
            setFormValid(false)
        }else{
            setFormValid(true)
        }
    },[emailError,passwordError])
    const handleInputChange = (e) => {
        const {id , value} = e.target;
        if(id === "firstName"){
            setFirstName(value);
            if(e.target.value.length<1)
            {
                setFirstNameError('Ім\'я не може бути пустим')
            }else{
                setFirstNameError("")
            }
        }
        if(id === "secondName"){
            setSecondName(value);
            if(e.target.value.length<1)
            {
                setSecondNameError('Прізвище не може бути пустим')
            }else{
                setSecondNameError("")
            }
        }
        if(id === "lastName"){
            setLastName(value);  
            if(e.target.value.length<1)
            {
                setLastNameError('По-батькові не може бути пустим')
            }else{
                setLastNameError("")
            }          
        }
        if(id === "email"){
            setEmail(value);
            if(!re.test(String(e.target.value).toLowerCase()))
            {
                setEmailError('Некоректний email')
            }else{
                setEmailError("")
            }
        }
        if(id === "password"){
            setPassword(value);
            if(!pas.test(String(e.target.value)))
            {
                setPasswordError('Пароль повинени містити не менше 6 символів, 1 цифри, 1 спецсимвола, 1 заглавної букви')
            }else{
                setPasswordError("")
            }
        }
        if(id === "confirmPassword"){
            setConfirmPassword(value);
        }

    }

    const blurHandler =(e) => {
        switch (e.target.id){
            case 'email':
                setEmailDirty(true)
                break
            case 'password':
                setPasswordDirty(true)
                break
            case 'firstName':
                setFirstNameDirty(true)
                break
            case 'secondName':
                setSecondNameDirty(true)
                break    
            case 'lastName':
                setLastNameDirty(true)
                break    
        }
    }

    const handleSubmit  = () => {
        if(password!=confirmPassword)
        {
        alert("Passwords must be the same")
        }
        else{
        console.log(firstName,lastName,email,password,confirmPassword);
        }
    }

    return(
        <div className="form">
            <div className="form-body">
            {(firstNameDirty&&firstNameError) && <div style={{color:'red'}}>{firstNameError}</div>}
                <div className="username">                    
                    <label className="form__label" for="firstName">First Name </label>
                    <input onBlur={e=>blurHandler(e)} className="form__input" type="text" value={firstName} onChange = {(e) => handleInputChange(e)} id="firstName" placeholder="First Name"/>
                </div>
                {(secondNameDirty&&secondNameError) && <div style={{color:'red'}}>{secondNameError}</div>}
                <div className="secondname">
                    <label className="form__label" for="secondName">First Name </label>
                    <input onBlur={e=>blurHandler(e)} id="secondName" className="form__input" type="text" value={secondName} onChange = {(e) => handleInputChange(e)} id="secondName" placeholder="Second Name"/>
                </div>
                {(lastNameDirty&&lastNameError) && <div style={{color:'red'}}>{lastNameError}</div>}
                <div className="lastname">
                    <label className="form__label" for="lastName">Last Name </label>
                    <input onBlur={e=>blurHandler(e)} type="text" id="lastName" value={lastName}  className="form__input" onChange = {(e) => handleInputChange(e)} placeholder="Last Name"/>
                </div>                
                {(emailDirty&&emailError) && <div style={{color:'red'}}>{emailError}</div>}
                <div className="email">                
                    <label className="form__label" for="email">Email </label>
                    <input onBlur={e=>blurHandler(e)} type="email" id="email" className="form__input" value={email} onChange = {(e) => handleInputChange(e)} placeholder="Email"/>
                </div>
                {(passwordDirty&&passwordError) && <div style={{color:'red'}}>{passwordError}</div>}
                <div className="password">                
                    <label className="form__label" for="password">Password </label>
                    <input onBlur={e=>blurHandler(e)} className="form__input" type="password"  id="password" value={password} onChange = {(e) => handleInputChange(e)} placeholder="Password"/>
                </div>
                <div className="confirm-password">
                    <label className="form__label" for="confirmPassword">Confirm Password </label>
                    <input className="form__input" type="password" id="confirmPassword" value={confirmPassword} onChange = {(e) => handleInputChange(e)} placeholder="Confirm Password"/>
                </div>
            </div>
            <div class="footer">
                <button disabled={!formValid} onClick={()=>handleSubmit()} type="submit" class="btn">Register</button>
            </div>
        </div>
       
    )       
}

export default RegistrationForm