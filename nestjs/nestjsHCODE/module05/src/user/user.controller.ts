
import { Controller, Post, Body, Get, Param, Put, Patch, Delete, ParseIntPipe } from '@nestjs/common';
import { CreateUserDTO } from './DTO/create-user.dto';
import { UpdatePutUserDTO } from './DTO/update-put-user.dto';
import { UpdatePatchUserDTO } from './DTO/update-patch-user.dto';
import { UserService } from './user.service';

@Controller('users')// /users
export class UserController {

  constructor(private readonly userService: UserService) {}

  @Post('postUser')
  async postUser(@Body() data: CreateUserDTO) {
    return await this.userService.createUser(data);
  }

  @Get('getAllUsers')
  async getAllUsers() {
    return await this.userService.getAllUsers();
  }

  @Get('getUser/:id')
  async getUser(@Param('id', ParseIntPipe) id) {
    return await this.userService.getUserById(id);
  }

  @Put('putUser/:id')
  async putUser(@Body() data: UpdatePutUserDTO, @Param('id', ParseIntPipe) id) {
    return await this.userService.putUser(data,id)
  }

  @Patch('patchUser/:id')
  async patchUser(@Body() data: UpdatePatchUserDTO, @Param('id', ParseIntPipe) id) {
    return await this.userService.patchUser(data, id)
  }

  @Delete('deleteUser/:id')
  async deleteUser(@Param('id', ParseIntPipe) id) { // ParseIntPipe converte ele para um number
    return await this.userService.deleteUser(id);
  }
}