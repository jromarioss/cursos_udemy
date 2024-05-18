import { IsDateString, IsEmail, IsOptional, IsString, IsStrongPassword } from "class-validator"

export class CreateUserDTO {
  @IsString()
  name: string;

  @IsEmail()
  email: string;

  @IsStrongPassword({
    minLength: 6, // ter 6 caracteres
    minUppercase: 1, // pelo menos ter um caractere maiúsculo
  })
  password: string;

  @IsOptional()
  @IsDateString()
  birthAt: string;
}