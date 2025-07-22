import axios from 'axios'
import type { 
  ApiResponse, 
  PaginatedResponse, 
  Course, 
  Instructor, 
  Student, 
  LoginRequest, 
  RegisterRequest, 
  AuthResponse 
} from '../types'

const api = axios.create({
  baseURL: '/api',
  headers: {
    'Content-Type': 'application/json',
  },
})

// Request interceptor to add auth token
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')
  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

// Response interceptor for error handling
api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem('token')
      localStorage.removeItem('user')
      window.location.href = '/login'
    }
    return Promise.reject(error)
  }
)

export const authApi = {
  login: (data: LoginRequest) => 
    api.post<ApiResponse<AuthResponse>>('/auth/login', data),
  
  register: (data: RegisterRequest) => 
    api.post<ApiResponse<AuthResponse>>('/auth/register', data),
  
  logout: () => 
    api.post<ApiResponse<null>>('/auth/logout'),
  
  me: () => 
    api.get<ApiResponse<Student | Instructor>>('/auth/me'),
}

export const coursesApi = {
  getAll: (params?: { 
    page?: number
    limit?: number
    category?: string
    level?: string
    search?: string
  }) => 
    api.get<ApiResponse<PaginatedResponse<Course>>>('/courses', { params }),
  
  getById: (id: string) => 
    api.get<ApiResponse<Course>>(`/courses/${id}`),
  
  create: (data: Partial<Course>) => 
    api.post<ApiResponse<Course>>('/courses', data),
  
  update: (id: string, data: Partial<Course>) => 
    api.put<ApiResponse<Course>>(`/courses/${id}`, data),
  
  delete: (id: string) => 
    api.delete<ApiResponse<null>>(`/courses/${id}`),
  
  enroll: (courseId: string) => 
    api.post<ApiResponse<null>>(`/courses/${courseId}/enroll`),
  
  unenroll: (courseId: string) => 
    api.delete<ApiResponse<null>>(`/courses/${courseId}/enroll`),
}

export const instructorsApi = {
  getAll: (params?: { 
    page?: number
    limit?: number
    search?: string
  }) => 
    api.get<ApiResponse<PaginatedResponse<Instructor>>>('/instructors', { params }),
  
  getById: (id: string) => 
    api.get<ApiResponse<Instructor>>(`/instructors/${id}`),
  
  update: (id: string, data: Partial<Instructor>) => 
    api.put<ApiResponse<Instructor>>(`/instructors/${id}`, data),
}

export const studentsApi = {
  getAll: (params?: { 
    page?: number
    limit?: number
    search?: string
  }) => 
    api.get<ApiResponse<PaginatedResponse<Student>>>('/students', { params }),
  
  getById: (id: string) => 
    api.get<ApiResponse<Student>>(`/students/${id}`),
  
  update: (id: string, data: Partial<Student>) => 
    api.put<ApiResponse<Student>>(`/students/${id}`, data),
}

export default api