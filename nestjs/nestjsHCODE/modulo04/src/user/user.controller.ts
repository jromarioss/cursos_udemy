import {
  Body,
  Controller,
  Delete,
  Get,
  Param,
  ParseIntPipe,
  Patch,
  Post,
  Put,
} from '@nestjs/common';
import { CreateUserDTO } from './dtos/create-user.dto';
import { UpdatePatchUserDTO } from './dtos/update-patch-user.dto';
import { UpdatePutUserDTO } from './dtos/update-put-user.dto copy';

@Controller('users')
export class UserController {
  @Post()
  async create(@Body() body: CreateUserDTO) {
    return { body };
  }

  @Get()
  async read() {
    return {
      users: [],
    };
  }

  @Get(':id')
  async readOne(@Param('id', ParseIntPipe) id: number) {
    return {
      user: {},
      id,
    };
  }

  @Put(':id')
  async update(
    @Body() { name, email, password }: UpdatePutUserDTO,
    @Param('id', ParseIntPipe) id: number,
  ) {
    return {
      method: 'put',
      name,
      email,
      password,
      id,
    };
  }

  @Patch(':id')
  async updatePartial(
    @Body() { name }: UpdatePatchUserDTO,
    @Param('id', ParseIntPipe) id: number,
  ) {
    return {
      method: 'patch',
      name,
      id,
    };
  }

  @Delete(':id') // converte para number
  async delete(@Param('id', ParseIntPipe) id: number) {
    return {
      id,
    };
  }
}
