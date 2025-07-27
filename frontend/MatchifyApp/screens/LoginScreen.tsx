import React, { useState } from 'react';
import { View, Text, TextInput, Button, Alert, StyleSheet, TouchableOpacity } from 'react-native';
import { NativeStackNavigationProp } from '@react-navigation/native-stack';
import { useNavigation } from '@react-navigation/native';

// Define the navigation stack parameter types
type RootStackParamList = {
  Login: undefined;
  Signup: undefined;
  Home: undefined;
};

// Type for navigation prop specific to Login screen
type LoginScreenNavigationProp = NativeStackNavigationProp<RootStackParamList, 'Login'>;

export default function LoginScreen() {
  // Get navigation object for screen transitions
  const navigation = useNavigation<LoginScreenNavigationProp>();

  // State variables for form fields and loading status
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [loading, setLoading] = useState(false);

  // Handles user login logic
  const handleLogin = async () => {
    // Validate that both fields are filled
    if (!username || !password) {
      Alert.alert('Please enter username and password');
      return;
    }

    setLoading(true);
    try {
      // Send login request to backend API
      const response = await fetch('http://localhost:8000/api/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ username, password }),
      });

      // Handle unsuccessful response
      if (!response.ok) {
        const errorData = await response.json();
        Alert.alert('Login Failed', errorData.detail || 'Invalid credentials');
        setLoading(false);
        return;
      }

      // Show success message and navigate to Home screen
      const data = await response.json();
      Alert.alert('Login Success', `Welcome ${data.username}`);

      // Reset navigation stack and go to Home after login
      navigation.reset({
        index: 0,
        routes: [{ name: 'Home' }],
      });
    } catch (error) {
      // Handle network or server errors
      Alert.alert('Error', 'Could not connect to server.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Login</Text>

      {/* Username input field */}
      <TextInput
        placeholder="Username"
        value={username}
        onChangeText={setUsername}
        autoCapitalize="none"
        style={styles.input}
      />

      {/* Password input field */}
      <TextInput
        placeholder="Password"
        value={password}
        onChangeText={setPassword}
        secureTextEntry
        style={styles.input}
      />

      {/* Login button */}
      <Button title={loading ? 'Logging in...' : 'Login'} onPress={handleLogin} disabled={loading} />

      {/* Link to go to Signup screen */}
      <TouchableOpacity onPress={() => navigation.navigate('Signup')} style={{ marginTop: 20 }}>
        <Text style={{ color: '#0284c7', textAlign: 'center' }}>Don't have an account? Sign Up</Text>
      </TouchableOpacity>
    </View>
  );
}

// Styles for the login screen components
const styles = StyleSheet.create({
  container: { flex: 1, justifyContent: 'center', padding: 20 },
  title: { fontSize: 24, marginBottom: 20, textAlign: 'center' },
  input: {
    height: 40,
    borderColor: 'gray',
    borderWidth: 1,
    marginBottom: 12,
    paddingHorizontal: 10,
    borderRadius: 5,
  },
});
