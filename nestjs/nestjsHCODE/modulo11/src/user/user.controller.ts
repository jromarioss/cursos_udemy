import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Patch,
  Post,
  Put,
  UseInterceptors,
  UseGuards,
} from '@nestjs/common';
import { CreateUserDTO } from './dtos/create-user.dto';
import { UpdatePatchUserDTO } from './dtos/update-patch-user.dto';
import { UpdatePutUserDTO } from './dtos/update-put-user.dto copy';
import { UserService } from './user.service';
import { Roles } from '../decorators/roles.decorator';
import { Role } from '../enums/role-enum';
import { AuthGuard } from '../guards/auth.guard';
import { LogInterceptor } from '../interceptors/log.interceptor';
import { RoleGuard } from '../guards/role.guard';
import { ParamId } from '../decorators/param-id.decorator';

@Roles(Role.Admin)
@UseGuards(AuthGuard, RoleGuard)
@UseInterceptors(LogInterceptor)
@Controller('users')
export class UserController {
  constructor(private readonly userService: UserService) {}

  @Post()
  async create(@Body() data: CreateUserDTO) {
    return this.userService.create(data);
  }

  @Get()
  async list() {
    return this.userService.list();
  }

  @Get(':id')
  async show(@ParamId() id: number) {
    return this.userService.show(id);
  }

  @Put(':id')
  async update(@Body() data: UpdatePutUserDTO, @Param() id: number) {
    return this.userService.update(id, data);
  }

  @Patch(':id')
  async updatePartial(@Body() data: UpdatePatchUserDTO, @ParamId() id: number) {
    return this.userService.updatePartial(id, data);
  }

  @Delete(':id') // converte para number
  async delete(@ParamId() id: number) {
    return {
      success: await this.userService.delete(id),
    };
  }
}
