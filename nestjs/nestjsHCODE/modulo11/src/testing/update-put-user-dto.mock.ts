import { Role } from '../enums/role-enum';
import { UpdatePutUserDTO } from '../user/dtos/update-put-user.dto copy';

export const updatePutUserDTO: UpdatePutUserDTO = {
  birthAt: '2000-01-01',
  email: 'joao@hcode.com.br',
  name: 'Joao Rangel',
  password: '123456',
  role: Role.User,
};
