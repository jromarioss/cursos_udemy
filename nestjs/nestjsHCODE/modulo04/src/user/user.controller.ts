
import { Controller, Post, Body, Get, Param, Put, Patch, Delete, ParseIntPipe } from '@nestjs/common';
import { CreateUserDTO } from './DTO/create-user.dto';
import { UpdatePutUserDTO } from './DTO/update-put-user.dto';
import { UpdatePatchUserDTO } from './DTO/update-patch-user.dto';

@Controller('users')// /users
export class UserController {

  @Post('postUser')
  async postUser(@Body() body: CreateUserDTO) {
    return {body};
  }

  @Get('getAllUsers')
  async getAllUsers() {
    return {users: []}
  }

  @Get('getUser/:id')
  async getUser(@Param('id', ParseIntPipe) id) {
    return {user: {}, id}
  }

  @Put('putUser/:id')
  async putUser(@Body() { name, email, password }: UpdatePutUserDTO, @Param('id', ParseIntPipe) id) {
    return { name, email, password, id }
  }

  @Patch('patchUser/:id')
  async patchUser(@Body() body: UpdatePatchUserDTO, @Param('id', ParseIntPipe) id) {
    return { body, id }
  }

  @Delete('deleteUser/:id')
  async deleteUser(@Param('id', ParseIntPipe) id) { // ParseIntPipe converte ele para um number
    return { id }
  }
}