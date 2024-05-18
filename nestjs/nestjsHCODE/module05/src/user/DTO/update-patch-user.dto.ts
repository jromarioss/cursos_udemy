import { PartialType } from '@nestjs/mapped-types';
import { CreateUserDTO } from './create-user.dto';
// extendendo assim não preciso criar do zero por que ele ja importa do create
export class UpdatePatchUserDTO extends PartialType(CreateUserDTO) {}